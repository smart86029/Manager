import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from './user';
import { UserService } from './user.service';

declare var $: any;

@Component({
  moduleId: module.id,
  selector: 'my-users',
  templateUrl: 'user-list.component.html',
  styleUrls: ['user-list.component.css']
})
export class UserListComponent implements OnInit {
  users: User[];
  newUser: User;
  selectedUser: User;
  errorMessage: string;

  constructor(
    private router: Router,
    private userService: UserService) { }

  ngOnInit(): void {
    this.getUsers();
    this.newUser = new User();
    this.selectedUser = new User();
    $('.modal').modal();
  }

  getUsers(): void {
    this.userService.getUsers()
      .subscribe(
        users => this.users = users,
        error => this.errorMessage = <any>error);
  }

  addUser(): void {
    this.userService.addUser(this.newUser)
      .subscribe(
      user => {
        this.users.push(user);
        $('#modal-new-user').modal('close');
      },
      error => this.errorMessage = <any>error);
  }

  editUser(): void {
    this.userService.editUser(this.selectedUser)
      .subscribe(
      user => {
        $('#modal-edit-user').modal('close');
      },
      error => this.errorMessage = <any>error);
  }

  onSelect(user: User): void {
    this.selectedUser = user;
  }

  gotoDetail(): void {
    this.router.navigate(['/detail', this.selectedUser.UserId]);
  }
}