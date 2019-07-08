import { Guid } from '../shared/guid';
import { Store } from './store';

export class Group {
  id: Guid;
  startTime: Date;
  endTime: Date;
  createdOn: Date;
  store: Store;
}
