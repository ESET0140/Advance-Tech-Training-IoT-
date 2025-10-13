#include "storage.h"
#include "stm3211xx_hal.h"
#include <string.h>
#include <stdio.h>
#include <time.h>

// Layout in Flash
#define READINGS_ADDR   FLASH_BASE_ADDR
#define INFO_ADDR       (FLASH_BASE_ADDR + 0x1000)  // separate block


void storage_init(void) {
    // Optionally check flash contents on boot
    // Could validate CRC and initialize empty block if invalid
}

// Save meter readings
int storage_save_readings(const meter_readings_t *data) {
    storage_readings_block_t block;
    memcpy(&block.readings, data, sizeof(meter_readings_t));
    block.crc = storage_calculate_crc((uint8_t*)&block.readings, sizeof(meter_readings_t));
    return flash_write(READINGS_ADDR, (uint8_t*)&block, sizeof(block));
}


int storage_load_readings(meter_readings_t *data) {
    
    storage_readings_block_t *block = (storage_readings_block_t*) READINGS_ADDR;
    uint32_t crc = storage_calculate_crc((uint8_t*)&block->days, sizeof(block->days));
    if (crc == block->crc && block->count > 0) {
     
        int idx = (block->head + STORAGE_DAYS_WINDOW - 1) % STORAGE_DAYS_WINDOW;
        memcpy(data, &block->days[idx].readings, sizeof(meter_readings_t));
        return 0;
    }
    return -1; 
}

int storage_save_info(const consumer_info_t *cinfo, const meter_hardware_info_t *hinfo) {
    storage_info_block_t block;
    memcpy(&block.consumer, cinfo, sizeof(consumer_info_t));
    memcpy(&block.hardware, hinfo, sizeof(meter_hardware_info_t));
    block.crc = storage_calculate_crc((uint8_t*)&block.consumer,
    sizeof(consumer_info_t) + sizeof(meter_hardware_info_t));
    return flash_write(INFO_ADDR, (uint8_t*)&block, sizeof(block));
}

// Load meter info
int storage_load_info(consumer_info_t *cinfo, meter_hardware_info_t *hinfo) {
    storage_info_block_t *block = (storage_info_block_t*) INFO_ADDR;
    uint32_t crc = storage_calculate_crc((uint8_t*)&block->consumer,
    sizeof(consumer_info_t) + sizeof(meter_hardware_info_t));
    if (crc == block->crc) {
        memcpy(cinfo, &block->consumer, sizeof(consumer_info_t));
        memcpy(hinfo, &block->hardware, sizeof(meter_hardware_info_t));
        return 0;
    }
    return -1;
}


static int storage_persist_block(const storage_readings_block_t *blk) {
    storage_readings_block_t copy = *blk;
  
    copy.crc = 0;
    copy.crc = storage_calculate_crc((uint8_t*)&copy, sizeof(storage_readings_block_t));
    return flash_write(READINGS_ADDR, (uint8_t*)&copy, sizeof(copy));
}


int storage_add_daily_reading(const meter_readings_t *data, time_t timestamp) {
    storage_readings_block_t *blk = (storage_readings_block_t*) READINGS_ADDR;
    storage_readings_block_t wb;
    memcpy(&wb, blk, sizeof(wb)); // read existing

    int write_idx = wb.head % STORAGE_DAYS_WINDOW;
    wb.days[write_idx].timestamp = timestamp;
    memcpy(&wb.days[write_idx].readings, data, sizeof(meter_readings_t));

    wb.head = (uint8_t)((write_idx + 1) % STORAGE_DAYS_WINDOW);
    if (wb.count < STORAGE_DAYS_WINDOW) wb.count++;

    return storage_persist_block(&wb);
}


int storage_refresh_90days(void) {
    storage_readings_block_t *blk = (storage_readings_block_t*) READINGS_ADDR;
    storage_readings_block_t wb;
    memcpy(&wb, blk, sizeof(wb));

    time_t now = time(NULL);
    if (wb.count == 0) {
     
        return -1;
    }
    int latest_idx = (wb.head + STORAGE_DAYS_WINDOW - 1) % STORAGE_DAYS_WINDOW;
    time_t latest_ts = wb.days[latest_idx].timestamp;
    double days_diff = difftime(now, latest_ts) / (60.0*60.0*24.0);

    if (days_diff >= 1.0) {
       
        int write_idx = wb.head % STORAGE_DAYS_WINDOW;
        memset(&wb.days[write_idx], 0, sizeof(wb.days[write_idx]));
        wb.days[write_idx].timestamp = now;
        wb.head = (uint8_t)((write_idx + 1) % STORAGE_DAYS_WINDOW);
        if (wb.count < STORAGE_DAYS_WINDOW) wb.count++;
        return storage_persist_block(&wb);
    }
    return 0; // no change
}


int storage_compile_report(uint8_t *out_buf, size_t *out_len) {
    if (!out_buf || !out_len) return -1;
    storage_readings_block_t *blk = (storage_readings_block_t*) READINGS_ADDR;
    char *p = (char*) out_buf;
    size_t cap = *out_len;
    size_t used = 0;

    int written = snprintf(p, cap, "timestamp,kWh_import,kVAh,voltage_avg,current_avg,power_factor_avg\n");
    if (written < 0) return -1;
    used += (size_t)written;
    p += written; cap = (cap > used) ? (cap - used) : 0;

    for (int i = 0; i < blk->count; i++) {
        int idx = (blk->head + STORAGE_DAYS_WINDOW - blk->count + i) % STORAGE_DAYS_WINDOW;
        daily_reading_t *d = &blk->days[idx];
        if (d->timestamp == 0) continue;
        written = snprintf(p, cap, "%llu,%.6f,%.6f,%.3f,%.3f,%.3f\n",
            (unsigned long long)d->timestamp,
            d->readings.kWh_import,
            d->readings.kVAh,
            d->readings.voltage_avg,
            d->readings.current_avg,
            d->readings.power_factor_avg);
        if (written < 0) break;
        used += (size_t)written;
        if (used >= *out_len) { used = *out_len; break; }
        p += written; cap = (cap > written) ? (cap - written) : 0;
    }
    *out_len = used;
    return 0;
}


int storage_encrypt_and_send_mqtt(const uint8_t *payload, size_t len) {
   
    printf("[storage] would encrypt %zu bytes and publish via MQTT\n", len);
    (void)payload;
     (void)len;
    return 0;
}
 