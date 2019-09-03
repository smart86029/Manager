import { Gender } from '../gender.enum';
import { Guid } from '../guid';
import { MaritalStatus } from '../marital-status.enum';

export class Employee {
  id: Guid;
  name: string;
  displayName: string;
  birthDate: Date;
  gender: Gender = Gender.notKnown;
  maritalStatus: MaritalStatus = MaritalStatus.notKnown;
}
