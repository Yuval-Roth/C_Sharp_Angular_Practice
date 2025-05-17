import {Component, ElementRef, signal, ViewChild} from '@angular/core';
import {CommentsControllerService} from '../services/comments-controller.service';
import {MatInput, MatInputModule} from '@angular/material/input';
import {MatList, MatListItem} from '@angular/material/list';
import {Comment} from '../models';
import {MatButton, MatButtonModule} from '@angular/material/button';

@Component({
  selector: 'app-postgresql-comments-page',
  imports: [MatInputModule, MatListItem, MatList, MatButtonModule],
  templateUrl: './postgresql-comments-page.component.html',
  styleUrl: './postgresql-comments-page.component.scss'
})
export class PostgresqlCommentsPageComponent {

  @ViewChild('commentInput') commentInput!: ElementRef<HTMLTextAreaElement>;
  @ViewChild('commentListContainer') commentList!: ElementRef<HTMLDivElement>;

  protected comments = signal<Comment[]>([]);

  constructor(private commentsController: CommentsControllerService) {
    this.commentsController.fetchComments("postgresql")
      .then(comments => {
        this.comments.set(comments);
        setTimeout(() => {
          this.commentList.nativeElement.scrollTop = this.commentList.nativeElement.scrollHeight;
        })
      });
  }

  protected addComment() {
    const comment = this.commentInput.nativeElement.value;
    if (comment && comment.trim() !== '') {
      const newComment = new Comment(comment, new Date().toLocaleTimeString());
      this.commentsController.addComment(newComment,"postgresql")
      .then(response => {
        if (response.Success) {
          this.comments.update(comments => [...comments, newComment]);
          this.commentInput.nativeElement.value = '';
          setTimeout(() => {
            this.commentList.nativeElement.scrollTop = this.commentList.nativeElement.scrollHeight;
          })
        } else {
          console.log("Failed to add comment: " + response.Message);
          alert("Failed to add comment: " + response.Message);
        }
      });
    }
  }
}
