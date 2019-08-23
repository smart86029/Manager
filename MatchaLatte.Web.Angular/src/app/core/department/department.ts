import { Guid } from '../guid';

export class Department {
  id: Guid;
  name: string;
  parentId?: Guid;
  children?: Department[] = [];
}
