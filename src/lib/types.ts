export type Blogger = {
  nickname: string
  username: string
  password: string
  email?: string
}

export type Post = {
  id: number
  blogger_username: string
  title: string
  content: string
  date: string
}

export type Bookmark = {
  blogger_username: string
  post_id: number
}
