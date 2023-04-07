<template>
  <div class="rating" id="rate">
    <div class="title-rating">
      Рейтинг
    </div>
    <div class="rate-kp">
      Оценка КиноПоиска: <span class="num-rate">{{kp}}</span>
    </div>
    <div class="rate-koda">
      Оценка Kodalib: {{kd}}
    </div>
    <div class="rate-users">
      Ваша оценка:
    </div>
    <rate :length="10" />
  </div>
</template>

<script>
import {ref} from "vue";

export default {
  name: "RatingComment",
  props:{
    rate:{
      type: Object
    }
  },
  setup(props){
    const kp = ref(props.rate.kinopoiskRating)
    const kd = ref(props.rate.ratingKoda)
    return{
      kp,
      kd,
    }
  }
}
</script>

<style scoped>

.rating{
  margin-right: 20px;
  border: 5px solid #503883;
  box-shadow: 0 0 20px #4e3883;
  border-radius: 30px;
  height: 100%;
  margin-top: 45px;
  padding: 10px;
}

.title-rating{
  text-align: center;
  margin: 0 0 20px;
  color: #ffddcc;
  font-size: 30px;
  font-weight: 600;
}

.rate-koda, .rate-kp,
.rate-users{
  color: #ffddcc;
  font-size: 24px;
  margin: 10px 0 0;
  padding-left: 7px;
}

.num-rate{
  font-size: 30px;
  color: #ffb996;
  font-weight: 600;
}
</style>