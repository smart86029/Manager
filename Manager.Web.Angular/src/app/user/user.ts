import { Role } from "../role/role";

export class User {
  UserId: number;
  UserName: string;
  IsEnabled: boolean;
  Roles: Role[];
}
