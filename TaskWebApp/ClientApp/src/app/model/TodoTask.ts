export class TodoTask {
  public taskid: number;
  public taskName: string;
  public creatorName: string;
  public description: string;
  public creationDate: Date;
  public isFinished: boolean;

  public clear() {
    this.taskid = null;
    this.taskName = this.creatorName = this.description = null;
    this.creationDate = null;
    this.isFinished = false;
  }
}
