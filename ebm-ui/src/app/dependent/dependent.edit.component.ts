import { Component, OnInit, Injectable, Input } from '@angular/core';
import { DependentModel } from './dependent.model';

@Component({
  selector: 'ebm-dependent-edit',
  templateUrl: './dependent.edit.component.html',
  styleUrls: ['./dependent.edit.component.scss']
})

@Injectable()
export class DependentEditComponent implements OnInit {

    @Input() currentDependent: DependentModel;
    title: string;

    constructor() { }

    ngOnInit(): void { }
}
