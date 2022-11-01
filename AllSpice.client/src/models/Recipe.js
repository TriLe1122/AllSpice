import { Account } from "./Account.js"

export class Recipe {
  constructor(data) {
    this.id = data.id
    this.creatorId = data.creatorId
    this.creator = new Account(data.creator)
    this.createdAt = data.createdAt
    this.updatedAt = data.updatedAt
    this.title = data.title
    this.instructions = data.instructions
    this.img = data.img
    this.category = data.category
    this.favoriteCount = data.favoriteCount
    this.archived = data.archived
    this.favorited = data.favorited || false
    this.favoriteId = data.favoriteId

  }
}