// Class that represents a letter in the wordle word and status
// of the letter in the wordle word
export enum LetterStatus {
  NotGuessed = 0,
  Correct,
  Misplaced,
  Wrong
}

export class Letter {
  char: string
  status: LetterStatus = LetterStatus.NotGuessed

  constructor(char: string, status?: LetterStatus) {
    this.char = char
    this.status = status ?? LetterStatus.NotGuessed
  }

  get color() {
        return 'grey'
    }
  }

