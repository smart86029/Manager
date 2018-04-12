import { Role } from '../role/role';

export class User {
  userId: number;
  userName: string;
  password: string;
  isEnabled: boolean;
  roles: Role[];
}
