export type Anchor = 'top' | 'right' | 'bottom' | 'left'
export type EdgeStyle = 'solid' | 'dashed' | 'dotted'
export type EdgeFormat = 'line' | 'curve' | 'diagonal' 
export type ItemType = 'topic' | 'subTopic' | 'link'

export type ItemContent = {
  title: string,
  description: string,
  links: Array<
  {text: string,
    url: string}
  >
}

export interface User {
  name?: string
  photo?: string
}

export interface Meta {
  keywords: [string, ...string[]],
  picture: string,
  description?: string
  title: string
  author: User
  contributors?: User[]
  createdAt: string
}

export interface Roadmap {
  meta?: Meta,
  items: RoadmapItem[],
  edges: RoadmapEdge[]
}

export interface Point {
  x: number;
  y: number;
}

export interface BoundingBox extends Point {
  width: number;
  height: number;
}

export interface RoadmapItem extends BoundingBox {
  id: string;
  content: ItemContent,
  type?: ItemType;
  editing?: boolean;
  linkTo?: string;
  label?: string;
  labelWidth?: number;
  labelSize?: number;
}


export interface RoadmapEdge{
  id: string,
  startItem: RoadmapItem,
  endItem: RoadmapItem,
  startItemAnchor: Anchor,
  endItemAnchor: Anchor
  format?: EdgeFormat,
  style?: EdgeStyle,
}
