#include "meter_info.h"
#include <string.h>

Consumer_info_t g_consumer_info;
Meter_hardware_info_t g_meter_hw_info;

void meter_info_init(void){

//consumer info
    strcpy(g_consumer_info.consumer_id, "CUST12345");
    Strcpy(g_consumer_info.consumer_name,"John Doe");
    strcpy(g_consumer_info.tariff_plan,"dOmestic");
    strcpy(g_consumer_info.adress,"123 Main St, City");

// hardware info
    strcpy(g_meter_hw_info.meter_serial,"STM32L1XX-0056");
    strcpy(g_meter_hw_info.firmware_version,"v1.0.0");
    strcpy(g_meter_hw_info.hardware_version,"RevA");

    g_meter_hw_info.voltage_calibration= 1.002f;
    g_meter_hw_info.current_calibration= 0.998f;
    g_meter_hw_info.power_calibration= 1.001f;

}