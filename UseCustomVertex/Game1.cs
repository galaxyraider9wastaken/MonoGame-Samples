#region File Description
//-----------------------------------------------------------------------------
// Game1.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using CustomVertex;

namespace UseCustomVertexWindows
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        BasicEffect basicEffect;
        Matrix worldMatrix;
        Matrix viewMatrix;
        Matrix projectionMatrix;

        const int number_of_vertices = 36;
        CustomVertex1[] cubeVertices;
        VertexBuffer vertexBuffer;

        GraphicsDeviceManager graphics;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        private void CreateVertexBuffer()
        {
            cubeVertices = new CustomVertex1[number_of_vertices];
            InitializeCube();

            vertexBuffer = new VertexBuffer(
                graphics.GraphicsDevice,
                typeof(CustomVertex1),
                number_of_vertices,
                BufferUsage.None
                );

            vertexBuffer.SetData<CustomVertex1>(cubeVertices);

            graphics.GraphicsDevice.SetVertexBuffer(vertexBuffer);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.SteelBlue);

            RasterizerState rasterizerState1 = new RasterizerState();
            rasterizerState1.CullMode = CullMode.None;
            graphics.GraphicsDevice.RasterizerState = rasterizerState1;

            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                graphics.GraphicsDevice.DrawPrimitives(
                    PrimitiveType.TriangleList,
                    0,  // start vertex
                    12  // number of primitives to draw
                );
            }
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            basicEffect = new BasicEffect(GraphicsDevice);
            CreateVertexBuffer();

            base.Initialize();
        }

        /// <summary>
        /// Initializes the vertices and indices of the 3D model.
        /// </summary>
        private void InitializeCube()
        {
            Vector3 LeftTopFront = new Vector3(-1.0f, 1.0f, 1.0f);
            Vector3 LeftBottomFront = new Vector3(-1.0f, -1.0f, 1.0f);
            Vector3 LeftTopBack = new Vector3(-1.0f, 1.0f, -1.0f);
            Vector3 LeftBottomBack = new Vector3(-1.0f, -1.0f, -1.0f);

            Vector3 RightTopFront = new Vector3(1.0f, 1.0f, 1.0f);
            Vector3 RightBottomFront = new Vector3(1.0f, -1.0f, 1.0f);
            Vector3 RightTopBack = new Vector3(1.0f, 1.0f, -1.0f);
            Vector3 RightBottomBack = new Vector3(1.0f, -1.0f, -1.0f);

            Vector2 textureLeftTop = new Vector2(0.0f, 0.0f);
            Vector2 textureLeftBottom = new Vector2(0.0f, 1.0f);
            Vector2 textureRightTop = new Vector2(1.0f, 0.0f);
            Vector2 textureRightBottom = new Vector2(1.0f, 1.0f);

            // Front face.
            cubeVertices[0] = new CustomVertex1(LeftTopFront, textureLeftTop);
            cubeVertices[1] = new CustomVertex1(LeftBottomFront, textureLeftBottom);
            cubeVertices[2] = new CustomVertex1(RightTopFront, textureRightTop);
            cubeVertices[3] = new CustomVertex1(LeftBottomFront, textureLeftBottom);
            cubeVertices[4] = new CustomVertex1(RightBottomFront, textureRightBottom);
            cubeVertices[5] = new CustomVertex1(RightTopFront, textureRightTop);

            // Back face.
            cubeVertices[6] = new CustomVertex1(LeftTopBack, textureRightTop);
            cubeVertices[7] = new CustomVertex1(RightTopBack, textureLeftTop);
            cubeVertices[8] = new CustomVertex1(LeftBottomBack, textureRightBottom);
            cubeVertices[9] = new CustomVertex1(LeftBottomBack, textureRightBottom);
            cubeVertices[10] = new CustomVertex1(RightTopBack, textureLeftTop);
            cubeVertices[11] = new CustomVertex1(RightBottomBack, textureLeftBottom);

            // Top face.
            cubeVertices[12] = new CustomVertex1(LeftTopFront, textureLeftBottom);
            cubeVertices[13] = new CustomVertex1(RightTopBack, textureRightTop);
            cubeVertices[14] = new CustomVertex1(LeftTopBack, textureLeftTop);
            cubeVertices[15] = new CustomVertex1(LeftTopFront, textureLeftBottom);
            cubeVertices[16] = new CustomVertex1(RightTopFront, textureRightBottom);
            cubeVertices[17] = new CustomVertex1(RightTopBack, textureRightTop);

            // Bottom face. 
            cubeVertices[18] = new CustomVertex1(LeftBottomFront, textureLeftTop);
            cubeVertices[19] = new CustomVertex1(LeftBottomBack, textureLeftBottom);
            cubeVertices[20] = new CustomVertex1(RightBottomBack, textureRightBottom);
            cubeVertices[21] = new CustomVertex1(LeftBottomFront, textureLeftTop);
            cubeVertices[22] = new CustomVertex1(RightBottomBack, textureRightBottom);
            cubeVertices[23] = new CustomVertex1(RightBottomFront, textureRightTop);

            // Left face.
            cubeVertices[24] = new CustomVertex1(LeftTopFront, textureRightTop);
            cubeVertices[25] = new CustomVertex1(LeftBottomBack, textureLeftBottom);
            cubeVertices[26] = new CustomVertex1(LeftBottomFront, textureRightBottom);
            cubeVertices[27] = new CustomVertex1(LeftTopBack, textureLeftTop);
            cubeVertices[28] = new CustomVertex1(LeftBottomBack, textureLeftBottom);
            cubeVertices[29] = new CustomVertex1(LeftTopFront, textureRightTop);

            // Right face. 
            cubeVertices[30] = new CustomVertex1(RightTopFront, textureLeftTop);
            cubeVertices[31] = new CustomVertex1(RightBottomFront, textureLeftBottom);
            cubeVertices[32] = new CustomVertex1(RightBottomBack, textureRightBottom);
            cubeVertices[33] = new CustomVertex1(RightTopBack, textureRightTop);
            cubeVertices[34] = new CustomVertex1(RightTopFront, textureLeftTop);
            cubeVertices[35] = new CustomVertex1(RightBottomBack, textureRightBottom);
        }

        /// <summary>
        /// Initializes the effect (loading, parameter setting, 
        /// and technique selection) used for the 3D model.
        /// </summary>
        private void InitializeEffect()
        {
            Texture2D texture = Content.Load<Texture2D>("XNA_pow2");
            //Texture2D texture = Content.Load<Texture2D>("Glass2");

            basicEffect.World = worldMatrix;
            basicEffect.View = viewMatrix;
            basicEffect.Projection = projectionMatrix;
            basicEffect.Texture = texture;
            basicEffect.TextureEnabled = true;

        }

        /// <summary>
        /// Initializes the transforms used for the 3D model.
        /// </summary>
        private void InitializeTransform()
        {
            float tilt = (float)Math.PI / 8.0f;
            worldMatrix = Matrix.CreateRotationX(tilt) * Matrix.CreateRotationY(tilt);

            viewMatrix = Matrix.CreateLookAt(new Vector3(0, 0, 10),
                Vector3.Zero, Vector3.Up);

            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(
                (float)Math.PI / 4.0f,  // 45 degrees, since 2 PI Radians is 360 degrees
                (float)GraphicsDevice.Viewport.Width /
                (float)GraphicsDevice.Viewport.Height,
                1.0f, 100.0f);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            InitializeTransform();
            InitializeEffect();
            InitializeCube();
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back ==
                ButtonState.Pressed)
                this.Exit();

#if WINDOWS || MONOMAC
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
#endif

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

    }
}
