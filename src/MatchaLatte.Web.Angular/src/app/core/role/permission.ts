import { Guid } from '../guid';

export class Permission {
  id: Guid;
  name: string;
  description: string;
  isEnabled: boolean;
}
