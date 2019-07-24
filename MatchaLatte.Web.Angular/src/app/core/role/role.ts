import { Guid } from '../guid';
import { Permission } from './permission';

export class Role {
  roleId: Guid;
  name: string;
  isEnabled: boolean;
  isChecked: boolean;
  Users: any;
  permissions: Permission[];
}
