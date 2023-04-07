<template>
  <div>
    <ul class="hover-effect-scale" v-show="typeFilm==='s'">
      <li class="film">
        <img :src="poster.poster" alt="">
        <div>
          <h3>{{ poster.title }}</h3>
          <a :href="'/series/'+ poster.id">Смотреть</a>
        </div>
      </li>
    </ul>
    <ul class="hover-effect-scale" v-show="typeFilm==='f'">
      <li class="film">
        <img :src="poster.poster" alt="">
        <div>
          <h3>{{ poster.title }}</h3>
          <a :href="'/film/'+ poster.id">Смотреть</a>
        </div>
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  name: "ItemCarousel",
  props: {
    poster: {
      type: String
    },
    typeFilm: {
      type: String
    }
  },
}
</script>

<style scoped>

.poster {
  width: 200px;
  height: 290px;
  object-position: center center;
  object-fit: cover;
}

ul {
  display: flex;
  flex-wrap: wrap;
}

li {
  list-style-type: none;
  margin-right: 20px;
  margin-bottom: 20px;
}

.hover-effect-scale {
  list-style: none;
  margin: 0 auto;
  width: 100%;
  text-align: center;
  padding: 0;
}

.hover-effect-scale li {
  position: relative;
  display: inline-block;
  box-shadow: 1px 3px 1px 0 rgba(0, 0, 0, 0.08);
  overflow: hidden;
}

/* Заголовок, текст и ссылка */
.hover-effect-scale li h3 {
  color: #fff;
  margin: 5px;
}

.hover-effect-scale li a {
  display: block;
  text-decoration: none;
  padding: 15px;
  color: #fff;
  background: #000;
  border-radius: 5px;
  margin: 0 auto;
  transition: all 0.4s ease-in-out;
}

.hover-effect-scale li a:hover {
  background: #454545;
  color: #fff;
}

/* Выезжающий блок с текстом */
.hover-effect-scale li > div {
  width: 100%;
  height: 100%;
  position: absolute;
  display: flex;
  justify-content: center;
  flex-direction: column;
}

.hover-effect-scale li:hover > div {
  position: absolute;
  overflow: hidden;
  top: 0;
  left: 0;
}

.hover-effect-scale li div {
  opacity: 0;
  background-color: rgba(0, 0, 0, 0.35); /* Фон блока при наведении */
  transition: all 0.4s ease-in-out;
  color: #fff;
}

.hover-effect-scale li img {
  width: 210px;
  background-color: #392661;
  height: 319px;
  transition: all 0.2s linear;
}

.hover-effect-scale li:hover img {
  transform: scale(1.3);
}

.hover-effect-scale li:hover div {
  opacity: 1;
}
</style>