import { Guid } from '../guid';
import { Role } from './role';

export class User {
  id: Guid;
  userName: string;
  password: string;
  name: string;
  displayName: string;
  isEnabled: boolean;
  roles: Role[];
}
