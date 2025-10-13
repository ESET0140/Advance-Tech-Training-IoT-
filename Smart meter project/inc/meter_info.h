#ifndef METER_INFO_H
#define METER_INFO_H

#include <stdint.h>

//Consumer Details
typedef struct {
char consumer_id[16];
    char consumer_name[32];
    char tariff_plan[16];
    char address[64];
} Consumer_info_t;
 
 typedef struct {
    
    char meter_serial[20];
    char firmware_version[12];
    char hardware_version[12];
    float voltage_calibration;
    float current_calibration;
    float power_calibration;
 } Meter_hardware_info_t;

// global instance
extern Consumer_info_t g_consumer_info;
extern Meter_hardware_info_t g_meter_hw_info;

    void meter_info_init(void);

    #endif