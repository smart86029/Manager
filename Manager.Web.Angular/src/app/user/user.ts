import { Role } from "../role/role";

export class User {
  UserId: number;
  UserName: string;
  Password: string;
  IsEnabled: boolean;
  Roles: Role[];
}
