import { Guid } from '../guid';

export class Permission {
  permissionId: Guid;
  name: string;
  description: string;
  isEnabled: boolean;
}
