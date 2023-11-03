import React from 'react';

import { css } from '@stitches/react';

interface Props {
  width: number;
  height: number;
  bgColor?: string;
}

const skeletonCss = ({
  width,
  height,
  backgroundColor
}: {
  width: number;
  height: number;
  backgroundColor: string;
}) =>
  css({
    backgroundColor,
    width,
    height,
    borderRadius: '8px'
  });

export default function Skeleton({
  height,
  width,
  bgColor = 'var(--wf-base-600)'
}: Props) {
  return (
    <div role="status" className="max-w-sm animate-pulse">
      <div
        className={skeletonCss({ backgroundColor: bgColor, width, height })()}
      />
      <span className="sr-only">Loading...</span>
    </div>
  );
}
