<template>
  <div class="poster">
    <img :src="seriesMedia.poster" class="poster-img">
  </div>
  <div class="trailer" v-show="seriesMedia.youtubeTrailer !== ''">
    <a :href="seriesMedia.youtubeTrailer" target="_blank">
      <button class="trailer-btn">
        <img src="@/assets/img/play.svg" class="trailer-img"/>
        Трейлер
      </button>
    </a>
  </div>
</template>

<script>
export default {
  props: {
    seriesMedia: {
      type: Object
    }
  }
}
</script>

<style scoped>
.poster {
  display: block;
}

.poster-img {
  width: 100%;
  height: 425px;
  object-position: center center;
  object-fit: cover;
  box-shadow: 0 0 20px #4e3883;
}

.trailer {
  margin-top: 35px;
  text-align: center;
}

.trailer-btn {
  display: flex;
  align-items: center;
  justify-content: center;
  border: 3px solid #4e3883;
  background: none;
  border-radius: 25px;
  width: 100%;
  font-size: 20px;
  line-height: 44px;
  color: #efefef;
  transition: all .5s ease;
  cursor: pointer;
}

.trailer-btn:hover {
  color: #ffddcc;
  font-size: 24px;
  background: #4e3883;
  transition: all .5s ease;
}

.trailer-img{
  width: 20px;
  height: 20px;
}

@media (max-width: 1340px) {
  .poster-img {
    width: 100%;
    height: 330px;
  }
}

@media (max-width: 1000px) {
  .poster-img {
    width: 100%;
    height: 385px;
  }
  .trailer-btn {
    border: 2px solid #4e3883;
    font-size: 16px;
  }

  .trailer-btn:hover {
    font-size: 20px;
  }

}

@media (max-width: 752px){
  .trailer{
    display: flex;
    justify-content: center;
  }

  .poster-img {
    width: 100%;
    height: auto;
  }
  .trailer-btn {
    width: 300px;
    border: 2px solid #4e3883;
    font-size: 16px;
  }

  .trailer-btn:hover {
    font-size: 20px;
  }

  .trailer-img{
    width: 15px;
    height: 15px;
  }
}

</style>