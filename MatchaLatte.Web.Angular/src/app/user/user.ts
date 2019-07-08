import { Role } from './role';
import { Guid } from '../shared/guid';

export class User {
  id: Guid;
  userName: string;
  password: string;
  isEnabled: boolean;
  roles: Role[];
}
