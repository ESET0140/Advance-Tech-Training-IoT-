#ifndef TAMPER_MONITOR_H
#define TAMPER_MONITOR_H

#include <stdint.h>

typedef enum {
    TAMPER_NONE = 0,
    TAMPER_MAGNETIC_INFLUENCE = 1,
    TAMPER_COVER_OPEN = 2,
    TAMPER_REVERSE_CURRENT = 3
} tamper_event_code_t;


// Function declarations
void tamper_monitor_init(uint32_t poll_interval_ms);

void tamper_monitor_poll(void);

int tamper_monitor_force_event(tamper_event_code_t code)

tamper_event_code_t tamper_cover_open(void);
tamper_event_code_t tamper_reverse_current(void);
tamper_event_code_t check_all_tamper_events(void);



#endif 