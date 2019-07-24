import { Guid } from '../guid';
import { Role } from './role';

export class User {
  id: Guid;
  userName: string;
  password: string;
  firstName: string;
  lastName: string;
  isEnabled: boolean;
  roles: Role[];
}
