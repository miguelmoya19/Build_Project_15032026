import { Component, Input, OnInit, Output, EventEmitter, SimpleChanges } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-generic-table',
  templateUrl: './generic-table.component.html',
  styleUrls: ['./generic-table.component.css']
})
export class GenericTableComponent implements OnInit {

  @Input() data: any[] = [];
  @Input() displayedColumns: string[] = [];
  @Input() rowStyle?: (row: any) => Record<string, string>;
  @Input() showActions: boolean = false;

  @Output() actionClick = new EventEmitter<any>();

  dataSource!: any;
  filterValue: string = '';
  finishLabel: string[] = [];

  constructor() {
    this.dataSource = new MatTableDataSource();
  }

  ngOnInit() {
    this.setupTable();
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['data'] && this.data) {
      this.setupTable(); 
    }
    console.log('test');
    
  }

  private setupTable() {
    this.dataSource.data = this.data;

    this.finishLabel = [...this.displayedColumns];
    if (this.showActions) {
      this.finishLabel.push('actions');
    }
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.filterValue = filterValue;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  onAction(row: any) {
    this.actionClick.emit(row);
  }
}