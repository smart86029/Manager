import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { map, switchMap } from 'rxjs/operators';
import { Guid } from 'src/app/shared/guid';
import { StoreService } from 'src/app/store/store.service';

import { Group } from '../group';
import { GroupService } from '../group.service';
import { Store } from '../store';

@Component({
  selector: 'app-group-join',
  templateUrl: './group-join.component.html',
  styleUrls: ['./group-join.component.scss']
})
export class GroupJoinComponent implements OnInit {
  isLoading = false;
  group = new Group();
  store = new Store();

  constructor(
    private groupService: GroupService,
    private storeService: StoreService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.isLoading = true;
    const id = this.route.snapshot.paramMap.get('id');
    this.groupService.getGroup(new Guid(id)).pipe(
      map(group => this.group = group),
      switchMap(group => this.storeService.getStore(group.store.storeId))
    ).subscribe({
      next: store => this.store = store,
      complete: () => this.isLoading = false
    });
  }
}
