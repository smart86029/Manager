import { Guid } from '../guid';

export class Permission {
  id: Guid;
  code: string;
  name: string;
  description: string;
  isEnabled: boolean;
}
