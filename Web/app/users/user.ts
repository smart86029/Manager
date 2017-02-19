import { Role } from '../roles/role';

export class User {
  UserId: number;
  UserName: string;
  IsEnabled: boolean = true;
  BusinessEntityId: number;
  BusinessEntity: any;
  Roles: Role[];
}