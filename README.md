# BlogStack

Simple vue.js application for publishing digital blogs world wide.

> Try it: [https://blog-stack.netlify.app/](https://blog-stack.netlify.app/)

## Prototype

![Splash Screen](./prototype/ui/Splash/Full%20HD.jpg)
![Login Screen](./prototype/ui/Login/Full%20HD.jpg)
![Register Screen](./prototype/ui/Register/Full%20HD.jpg)
![Explore Screen](./prototype/ui/Explore/Full%20HD.jpg)
![MyBlog Screen](./prototype/ui/My%20Blog/Full%20HD.jpg)
![AddPost Screen](./prototype/ui/Add%20Post/Full%20HD.jpg)
![EditPost Screen](./prototype/ui/Edit%20Post/Full%20HD.jpg)
![Post Screen](./prototype/ui/PostPage/Full%20HD.jpg)

## Data Representation

### Blogger

```TypeScript
{
    nickname: string,
    username: string,
    password: string,
    email?: string
}
```

### Post

```TypeScript
{
    id: number,
    blogger_username: string,
    title: string,
    content: string,
    date: string
}
```

### Bookmark

```TypeScript
{
    blogger_username: string,
    post_id: number
}
```

## Type Support for `.vue` Imports in TS

TypeScript cannot handle type information for `.vue` imports by default, so we replace the `tsc` CLI with `vue-tsc` for type checking. In editors, we need [Volar](https://marketplace.visualstudio.com/items?itemName=Vue.volar) to make the TypeScript language service aware of `.vue` types.

## Customize configuration

See [Vite Configuration Reference](https://vitejs.dev/config/).

## Project Setup

```sh
pnpm install
```

### Compile and Hot-Reload for Development

```sh
pnpm dev
```

### Type-Check, Compile and Minify for Production

```sh
pnpm build
```

### Lint with [ESLint](https://eslint.org/)

```sh
pnpm lint
```
