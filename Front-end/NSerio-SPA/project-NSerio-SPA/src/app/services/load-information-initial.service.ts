import { Injectable } from '@angular/core';
import { NserioApiService } from './nserio-api.service';
import { map, switchMap, tap } from 'rxjs';
import { ResponseModelGenericStatus } from '../interfaces/ICodeGenericModel';
import { responseModel } from '../Shared/responseModel';

@Injectable({
  providedIn: 'root',
})
export class LoadInformationInitialService {
  constructor(private apiService: NserioApiService) {}

  public Initialnformation() {
    return this.apiService
      .getAppNSerio('Task/multiResult')
      .pipe(tap((res: responseModel<ResponseModelGenericStatus>) => map((res) => res)));
  }
}


