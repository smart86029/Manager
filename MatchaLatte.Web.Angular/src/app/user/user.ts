import { Role } from './role';
import { Guid } from '../shared/guid';

export class User {
  userId: Guid;
  userName: string;
  password: string;
  isEnabled: boolean;
  roles: Role[];
}
