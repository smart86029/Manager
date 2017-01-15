"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
require('rxjs/add/operator/switchMap');
var core_1 = require('@angular/core');
var router_1 = require('@angular/router');
var common_1 = require('@angular/common');
var role_service_1 = require('./role.service');
var RoleDetailComponent = (function () {
    function RoleDetailComponent(roleService, route, location) {
        this.roleService = roleService;
        this.route = route;
        this.location = location;
    }
    RoleDetailComponent.prototype.ngOnInit = function () {
        //this.route.params
        //  .switchMap((params: Params) => this.roleService.getRole(+params['id']))
        //  .subscribe(role => this.role = role);
    };
    RoleDetailComponent.prototype.goBack = function () {
        this.location.back();
    };
    RoleDetailComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'my-role-detail',
            templateUrl: 'role-detail.component.html',
            styleUrls: ['role-detail.component.css']
        }), 
        __metadata('design:paramtypes', [role_service_1.RoleService, router_1.ActivatedRoute, common_1.Location])
    ], RoleDetailComponent);
    return RoleDetailComponent;
}());
exports.RoleDetailComponent = RoleDetailComponent;
//# sourceMappingURL=role-detail.component.js.map