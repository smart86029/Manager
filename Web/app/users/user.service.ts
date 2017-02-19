import { Injectable } from              '@angular/core';
import { Headers, Response, Http, RequestOptions } from '@angular/http';

import { User } from       './user';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class UserService {
  private usersUrl = 'api/Users';

  constructor(private http: Http) { }

  getUsers(): Observable<User[]> {
    return this.http.get(this.usersUrl)
      .map(this.extractData)
      .catch(this.handleError);
  }

  //getRole(id: number): Promise<Role> {
  //  return this.getRoles()
  //    .then(roles => roles.find(role => role.roleId === id));
  //}

  addUser(user: User): Observable<User> {
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });
    return this.http.post(this.usersUrl, user, options)
      .map(this.extractData)
      .catch(this.handleError);
  }

  editUser(user: User): Observable<User> {
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });
    return this.http.put(`${this.usersUrl}/${user.UserId}`, user, options)
      .map(this.extractData)
      .catch(this.handleError);
  }

  private extractData(res: Response) {
    let body = res.json();
    return body;
  }

  private handleError(error: Response | any) {
    // In a real world app, we might use a remote logging infrastructure
    let errMsg: string;
    if (error instanceof Response) {
      const body = error.json() || '';
      const err = body.error || JSON.stringify(body);
      errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
    } else {
      errMsg = error.message ? error.message : error.toString();
    }
    console.error(errMsg);
    return Observable.throw(errMsg);
  }
}