import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ChangeInformationService<T> {
  private data = new BehaviorSubject<T>(null);

  constructor() {}

  public getterSubject() {
    return this.data.asObservable();
  }

  public setterSubject(data: T) {
    this.data.next(data);
  }
}
