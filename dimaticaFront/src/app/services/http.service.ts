import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Duty } from '../components/dutylist/DutyModel';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  private REST_API_SERVER = "https://localhost:44382/api/duties/";
  constructor(private httpClient: HttpClient) { }

  handleError(error: HttpErrorResponse) {
    let errorMessage = 'Unknown error!';
    if (error.error instanceof ErrorEvent) {
      // Client-side errors
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Server-side errors
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
  }
  
  public sendGetRequest(){
    return this.httpClient.get(this.REST_API_SERVER).pipe(catchError(this.handleError));;
  }

  public sendPostRequest(duty:Duty){
    return this.httpClient.post<Duty>(this.REST_API_SERVER,duty).pipe(catchError(this.handleError));;
  }
  public DeleteRequest(id:string){
    return this.httpClient.delete(this.REST_API_SERVER+id).pipe(catchError(this.handleError));;
  }
  public PutRequest(id:string,duty:Duty){
    return this.httpClient.put(this.REST_API_SERVER+id,duty).pipe(catchError(this.handleError));;
  }
}
