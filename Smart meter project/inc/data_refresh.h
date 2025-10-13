#ifndef DATA_REFRESH_H
#define DATA_REFRESH_H

#include "meter_readings.h"
#include "meter_info.h"

void data_refresh_init(void);
void data_refresh_add_entry(const daily_data_t *entry);
void data_refresh_send_report(void);

#endif