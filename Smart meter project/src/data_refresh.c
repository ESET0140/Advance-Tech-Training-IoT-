#include "data_refresh.h"
#include "Meter_info.h"
#include "Meter_Readings.h"
#include <string.h>
#include <stdio.h>
#include <time.h>

#define MAX_DAYS 90
#define REPORT_TOPIC "meter/report/90days"

#ifndef REFRESH_LOG
#define REFRESH_LOG(fmt, ...)printf("[Refresh]" fmt"\n", ##_VA_ARGS__)


static daily_data_t daily_store[MAX_DAYS];
static uint8_t entry_count = 0;
static uint8_t head_index =0;


static uint32_t get current time(void){

    #ifndef HAL_EXISTS
        return (uint32_t)time(NULL);

        sync();
    #else

    return (uint32_t)time(NULL);

}
    static skize_t serialize_report(uit6_t *out_buf, size_t max_len){
    }

        static void data_refresh_init(void){
            memset(daily_store,0,sizeof(daily_store));
            entry count = 0;
            head_index = 0;
            REFRESH_LOG("initialised daily data store(max %d days)", MAX_DAYS)
        }

void data_refresh_add_entry(const daily_data_t *entry){
    if (entry_count < MAX_DAYS) {
        // Still space, add at the next position
        daily_store[entry_count++] = *entry;
        REFRESH_LOG("Added entry. Total entries: %d, Head index: %d", entry_count, head_index);
    } else {
        // Storage full, overwrite the oldest entry (circular buffer)
        daily_store[head_index] = *entry;
        head_index = (head_index + 1) % MAX_DAYS;
    }
}

             
      