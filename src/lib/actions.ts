import { bloggers, posts, bookmarks } from './placeholders'
import type { Blogger, Post } from './types'

export async function getBloggers() {
  return bloggers
}

export async function getPosts() {
  return posts
}

export async function getBookmarks() {
  return bookmarks
}

export async function getPostsOf(username: string) {
  const posts = await getPosts()
  return posts.filter((obj) => obj.blogger_username === username)
}

export async function getBookmarkedPostsOf(username: string) {
  const posts = await getPosts()
  const bookmarks = await getBookmarks()
  const filtered_bookmarks = bookmarks.filter((obj) => obj.blogger_username === username)
  return filtered_bookmarks.map((bookmark) =>
    posts.find((post) => post.id === bookmark.post_id)
  ) as Array<Post>
}

export async function getPopular() {
  return posts.slice(0, 5)
}

export async function addPost(post: Omit<Post, 'id'>) {
  return
}

export async function auth(username: string, password: string) {
  const bloggers = await getBloggers()
  const blogger = bloggers.find((blogger) => blogger.username === username)
  if (blogger && blogger.password === password) {
    return true
  }
  return false
}

export async function signIn(username: string, password: string) {
  return auth(username, password)
}

export async function signOut() {
  return true
}

export async function register(user: Blogger) {
  return false
}

// TODO: all server side effects shall be declared here

// export async function authToken(token: string) {
//   return true
// }
