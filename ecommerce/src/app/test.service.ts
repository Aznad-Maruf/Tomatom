import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable()
export class TestService {
  private info = new BehaviorSubject('information');

  getInfo(): Observable<string> {
    return this.info.asObservable();
  }

  getInfoValue(): string {
    return this.info.getValue();
  }

  setInfo(val: string) {
    this.info.next(val);
  }
}