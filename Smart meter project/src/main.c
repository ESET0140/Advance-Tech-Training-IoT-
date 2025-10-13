#include "data_refresh.h"
#include "storage.h"
#include "meter_info.h"
#include "meter_readings.h"
#include <string.h>
#include <stdint.h>
#include <stdio.h>
#include <time.h>
#include "stm32f3xx_hal.h"
 
 
void main (void) {
    HAL_Init();
    // System clock config here
 
    meter_info_init();
    storage_init();
    data_refresh_init();
 
    // Load existing info
    if (storage_load_info(&g_consumer_info, &g_meter_hw_info) != 0) {
        // Handle error or initialize defaults
    }
 
    // Load existing readings
    meter_readings_t current_readings;
    if (storage_load_readings(&current_readings) != 0) {
        // Handle error or initialize defaults
    }
 
    // Main loop
    while (1) {
        // Simulate reading new data
        daily_data_t new_entry = {
            .timestamp = (uint32_t)time(NULL),
            .energy_consumed = 5.0, // Example value
            .peak_demand = 1.5      // Example value
        };
        data_refresh_add_entry(&new_entry);
 
        // Periodically send report
        data_refresh_send_report();
 
        HAL_Delay(60000); // Delay for 1 minute (example)
    }
}