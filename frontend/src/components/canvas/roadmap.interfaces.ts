export type Point = [number, number]
export type Item = Topic | SubTopic | Reference | Legend
export type Topic = ItemBase
export type SubTopic = ItemBase
export type Reference = ItemBase
export type Legend = ItemBase

export interface MySchema {
  meta?: {
    keywords: [string, ...string[]]
    description?: string
    title: string
    author: User
    contributors?: User[]
    createdAt: string
    [k: string]: unknown
  }
  edges?: Edge[]
  items?: Item[]
  [k: string]: unknown
}
export interface User {
  name?: string
  photo?: string
  [k: string]: unknown
}
export interface Edge {
  start: Point
  end: Point
  format?: 'line' | 'curve'
  color?: string
  style?: 'solid' | 'dashed' | 'dotted'
  [k: string]: unknown
}
export interface ItemBase {
  title: string
  content?: string
  pos: Point
  dim: Point
  [k: string]: unknown
}