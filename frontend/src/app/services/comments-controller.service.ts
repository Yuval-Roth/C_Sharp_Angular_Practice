import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Comment, Response } from '../models';
import {firstValueFrom} from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class CommentsControllerService {

  constructor(private http: HttpClient) { }

  fetchComments(db: String): Promise<Comment[]> {
    const url = `http://localhost:5000/comments/${db}`;
    const body = JSON.stringify({
      "Type":"FetchComments"
    })
    return firstValueFrom(this.http.post(url,body,{responseType: 'json'}))
      .then((returned: any) => {
        let response = returned as Response;
        if(response.Success && response.Data != null) {
          return response.Data.map((comment: string) => JSON.parse(comment));
        } else {
          console.log("Failed to fetch comments: "+response.Message);
          return [];
        }
      }).catch(error => {
        console.log("Failed to fetch comments: "+error);
        return [];
      }
    )
  }

  addComment(comment: Comment, db: string): Promise<Response> {
    const url = `http://localhost:5000/comments/${db}`;
    const body = JSON.stringify({
      "Type":"AddComment",
      "Content": comment.Content,
      "Timestamp": comment.Timestamp
    })
    return firstValueFrom(this.http.post(url,body,{responseType: 'json'}))
      .then((returned: any) => {
        return returned as Response;
      }).catch(error => {
        console.log("Failed to add comment: "+error);
        return new Response("Failed to add comment", false, null);
      }
    )
  }
}
