import { MatDateFormats } from '@coachcare/datepicker';

export const APP_DATE_FORMATS: MatDateFormats = {
  parse: {
    date: ['YYYY-MM-DD', 'YYYY/MM/DD', 'll'],
    datetime: ['YYYY-MM-DD HH:mm', 'YYYY/MM/DD HH:mm', 'll h:mma'],
    time: ['H:mm', 'HH:mm', 'h:mm a', 'hh:mm a']
  },
  display: {
    date: 'll',
    datetime: 'YYYY-MM-DD HH:mm:ss',
    time: 'h:mm a',
    dateA11yLabel: 'YYYY-MM-DD HH:mm:ss',
    monthDayLabel: 'MMM D',
    monthDayA11yLabel: 'MMMM D',
    monthYearLabel: 'MMMM YYYY',
    monthYearA11yLabel: 'MMMM YYYY',
    timeLabel: 'HH:mm'
  }
};
