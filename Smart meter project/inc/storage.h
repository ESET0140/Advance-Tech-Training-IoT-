#ifndef STORAGE_H
#define STORAGE_H

#include <stdint.h>
#include <stddef.h>
#include "meter_info.h"
#include "meter_reading.h"

/* Minimal storage header matching the stub implementations. Replace with
   full original header as needed. */

void storage_init(void);
int storage_save_readings(const meter_readings_t *data);
int storage_load_readings(meter_readings_t *data);

int storage_add_daily_reading(const meter_readings_t *data, long timestamp);
int storage_refresh_90days(void);
int storage_compile_report(uint8_t *out_buf, size_t *out_len);
int storage_encrypt_and_send_mqtt(const uint8_t *payload, size_t len);

int storage_save_info(const consumer_info_t *consumer, const meter_hardware_info_t *hinfo);
int storage_load_info(consumer_info_t *consumer, meter_hardware_info_t *hinfo);

uint32_t storage_calculate_crc(const uint8_t *data, size_t length);

#endif /* STORAGE_H */
typedef struct{

