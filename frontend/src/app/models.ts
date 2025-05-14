export class Comment {
  constructor(
    public Content: string,
    public Timestamp: string
  ){}
}

export class Response {
  constructor(
    public Message: string | null,
    public Success: boolean,
    public Data: string[] | null
  ){}
}
