import { Guid } from '../guid';
import { Store } from './store';

export class Group {
  id: Guid;
  startOn: Date;
  endOn: Date;
  remark: string;
  createdOn: Date;
  store: Store;
}
