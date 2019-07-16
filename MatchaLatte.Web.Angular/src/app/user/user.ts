import { Role } from './role';
import { Guid } from '../shared/guid';

export class User {
  id: Guid;
  userName: string;
  password: string;
  firstName: string;
  lastName: string;
  isEnabled: boolean;
  roles: Role[];
}
