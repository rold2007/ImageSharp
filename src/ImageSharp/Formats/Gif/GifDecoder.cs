﻿// <copyright file="GifDecoder.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.Formats
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using ImageSharp.PixelFormats;

    /// <summary>
    /// Decoder for generating an image out of a gif encoded stream.
    /// </summary>
    public class GifDecoder : IImageDecoder
    {
        /// <summary>
        /// Gets or sets a value indicating whether the metadata should be ignored when the image is being decoded.
        /// </summary>
        public bool IgnoreMetadata { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the additional frames should be ignored when the image is being decoded.
        /// </summary>
        public bool IgnoreFrames { get; set; } = false;

        /// <summary>
        /// Gets or sets the encoding that should be used when reading comments.
        /// </summary>
        public Encoding TextEncoding { get; set; } = GifConstants.DefaultEncoding;

        /// <inheritdoc/>
        public Image<TPixel> Decode<TPixel>(Configuration configuration, Stream stream)
            where TPixel : struct, IPixel<TPixel>
        {
            var decoder = new GifDecoderCore<TPixel>(this.TextEncoding, configuration);
            decoder.IgnoreMetadata = this.IgnoreMetadata;
            decoder.IgnoreFrames = this.IgnoreFrames;
            return decoder.Decode(stream);
        }
    }
}
