import { Guid } from '../guid';
import { Permission } from './permission';

export class Role {
  id: Guid;
  name: string;
  isEnabled: boolean;
  isChecked: boolean;
  Users: any;
  permissions: Permission[];
}
