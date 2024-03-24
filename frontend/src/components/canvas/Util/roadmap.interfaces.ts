export type Anchor = 'top' | 'right' | 'bottom' | 'left'
export type EdgeStyle = 'solid' | 'dashed' | 'dotted'
export type EdgeFormat = 'line' | 'curve' | 'diagonal' 
export type EdgeDirection = 'lineX' | 'lineY' | 'lineXY'

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
  type?: string;
  editing?: boolean;
}


export interface RoadmapEdge{
  id: string,
  startItemId: string,
  endItemId: string,
  startItemAnchor: Anchor,
  endItemAnchor: Anchor
  format?: EdgeFormat,
  style?: EdgeStyle,
  direction?: EdgeDirection
}
