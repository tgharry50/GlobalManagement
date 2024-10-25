// Utilities
import { defineStore } from 'pinia'
import { UserData } from '@/typescript_types/globals'
export const useAppStore = defineStore('app', {
  state: () => ({
     user: <UserData>{},
     loggedin: <boolean> false
  }),
  actions: {
    async SetUserData(params: UserData): Promise<boolean> {
      try{
        this.user.uuid = params.uuid
        this.user.username = params.username
        this.user.firstname = params.firstname
        this.user.lastname = params.lastname
        this.user.email = params.email
        this.user.card = params.card
        this.user.pin = params.pin
        this.loggedin = true
        return this.loggedin;
      } catch(error){
        console.error(error)
        throw error
      }
    }
  }
})
