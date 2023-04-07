<template>
  <div>
    <div class="genres">
      <div class="genre" v-for="(genre, index) in seriesInformation.genres" :key="index">
        {{ genre }}
      </div>
    </div>

    <div class="plot">
      {{ seriesInformation.plot }}
    </div>
    <div class="people">
      <div class="person-title">
        <div v-show="seriesInformation.director.length !== 0">
          Режиссер
        </div>
        <div v-show="seriesInformation.writer.length !== 0">
          Сценарист
        </div>
      </div>
      <div class="person-name">
        <div>
          {{seriesInformation.director.join(", ")}}
        </div>
        <div>
          {{seriesInformation.writer.join(", ")}}
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    seriesInformation: {
      type: Object
    }
  },
}
</script>

<style scoped>
.genre {
  display: inline-block;
  color: #4e3883;
  font-size: 15px;
  line-height: 30px;
  padding: 1px 27px;
  background: #ffddcc;
  border-radius: 22px;
  font-weight: bold;
  margin: 0 15px 10px 0;
}

.plot {
  margin: 15px 0 20px;
  color: #efefef;
  font-size: 20px;
  line-height: 30px;
  font-weight: 400;
}

.people{
  display: flex;
}

.person-name{
  color: #efefef;
  margin-left: 15px;

}

.person-title {
  color: rgba(255, 255, 255, 0.6);
}

.person-title div, .person-name div {
  margin-bottom: 15px;
}

@media (max-width: 1340px) {
  .plot {
    font-size: 16px;
  }
}
@media (max-width: 1000px){
  .plot {
    font-size: 14px;
  }
}

@media (max-width: 752px){

  .genres{
    display: flex;
    flex-wrap: wrap;
  }
  .genre {
    font-size: 16px;
    line-height: 25px;
    padding: 3px 25px;
    margin: 0 10px 10px 0;
  }
  .plot {
    font-size: 18px;
  }
}
</style>